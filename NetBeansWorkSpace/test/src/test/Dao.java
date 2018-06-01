/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import java.util.List;
import javax.persistence.Persistence;

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
        if(flag)
        {
            flag=false;
            return size=getAllStu().size();   
        }
        else
           return size; 
    }
    public static void save(Stu stu)
    {
        try {
            controller.create(stu);
            flag=true;
            System.out.println("插入成功");
        } catch (Exception e) {
            System.out.println("保存失败");
        }
    }
}
