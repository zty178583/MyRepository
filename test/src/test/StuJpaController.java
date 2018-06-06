/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import java.io.Serializable;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Query;
import javax.persistence.EntityNotFoundException;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;
import test.exceptions.NonexistentEntityException;
import test.exceptions.PreexistingEntityException;

/**
 *
 * @author Administrator
 */
public class StuJpaController implements Serializable {

    public StuJpaController(EntityManagerFactory emf) {
        this.emf = emf;
    }
    private EntityManagerFactory emf = null;

    public EntityManager getEntityManager() {
        return emf.createEntityManager();
    }

    public void create(Stu stu) throws PreexistingEntityException, Exception {
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            em.persist(stu);
            em.getTransaction().commit();
        } catch (Exception ex) {
            if (findStu(stu.getId()) != null) {
                throw new PreexistingEntityException("Stu " + stu + " already exists.", ex);
            }
            throw ex;
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public void edit(Stu stu) throws NonexistentEntityException, Exception {
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            stu = em.merge(stu);
            em.getTransaction().commit();
        } catch (Exception ex) {
            String msg = ex.getLocalizedMessage();
            if (msg == null || msg.length() == 0) {
                Integer id = stu.getId();
                if (findStu(id) == null) {
                    throw new NonexistentEntityException("The stu with id " + id + " no longer exists.");
                }
            }
            throw ex;
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public void destroy(Integer id) throws NonexistentEntityException {
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            Stu stu;
            try {
                stu = em.getReference(Stu.class, id);
                stu.getId();
            } catch (EntityNotFoundException enfe) {
                throw new NonexistentEntityException("The stu with id " + id + " no longer exists.", enfe);
            }
            em.remove(stu);
            em.getTransaction().commit();
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public List<Stu> findStuEntities() {
        return findStuEntities(true, -1, -1);
    }

    public List<Stu> findStuEntities(int maxResults, int firstResult) {
        return findStuEntities(false, maxResults, firstResult);
    }

    private List<Stu> findStuEntities(boolean all, int maxResults, int firstResult) {
        EntityManager em = getEntityManager();
        try {
            CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
            cq.select(cq.from(Stu.class));
            Query q = em.createQuery(cq);
            if (!all) {
                q.setMaxResults(maxResults);
                q.setFirstResult(firstResult);
            }
            return q.getResultList();
        } finally {
            em.close();
        }
    }

    public Stu findStu(Integer id) {
        EntityManager em = getEntityManager();
        try {
            return em.find(Stu.class, id);
        } finally {
            em.close();
        }
    }

    public int getStuCount() {
        EntityManager em = getEntityManager();
        try {
            CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
            Root<Stu> rt = cq.from(Stu.class);
            cq.select(em.getCriteriaBuilder().count(rt));
            Query q = em.createQuery(cq);
            return ((Long) q.getSingleResult()).intValue();
        } finally {
            em.close();
        }
    }
    
}
