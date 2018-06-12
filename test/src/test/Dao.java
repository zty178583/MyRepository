/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.persistence.Persistence;
import test.exceptions.NonexistentEntityException;

/**
 *
 * @author Administrator
 */
public class Dao {
    private static boolean flag=true;
    private static int size;
    private static final StuJpaController controller=new StuJpaController(Persistence.createEntityManagerFactory("testPU"));
    public static List<Stu> getAllStu()
    {
        List<Stu> findStuEntities = controller.findStuEntities();
        return findStuEntities;
    }
    public static Stu getStu(int id)
    {
        Stu findStu = controller.findStu(id);
        return findStu;
    }
    public static int getSize()
    {
        //System.out.println("test.Dao.getSize()");
        if(flag)
        {
            flag=false;
            return size=getAllStu().size();   
        }
        else
           return size; 
    }
    public static String save(Stu stu)
    {
        try {
            controller.create(stu);
            flag=true;
            System.out.println("插入成功");
            return "插入成功";
        } catch (Exception e) {
            System.out.println("插入失败");
            return "插入失败"+e.getMessage();
        }
    }
    public static int getScore(String name)
    {
        int score=0;
        for (Stu stu : controller.findStuEntities()) {
            if(stu.getName().equals(name))
            {
                score=stu.getScore();
            }
        }
        return score;
    }

    static void delete(Stu stu) {
        try {
            controller.destroy(stu.getId());
        } catch (NonexistentEntityException ex) {
            System.out.println("删除失败");
        }
    }
}
