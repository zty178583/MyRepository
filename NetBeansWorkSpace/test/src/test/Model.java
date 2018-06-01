/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import javax.swing.DefaultComboBoxModel;
import javax.swing.event.ListDataListener;

/**
 *
 * @author Administrator
 */
public class Model extends DefaultComboBoxModel{

            Stu stu=null;
            @Override
            public void setSelectedItem(Object anItem) {
                stu=(Stu) anItem;
            }

            @Override
            public Object getSelectedItem() {
                return stu;
            }

            @Override
            public int getSize() {
                return Dao.getSize();
            }

            @Override
            public Object getElementAt(int index) {
//                System.out.println(".getElementAt()");
                System.out.println(Dao.getStu(index+1).getName());
                return Dao.getStu(index+1);
            }

            @Override
            public void addListDataListener(ListDataListener l) {
                System.out.println(".addListDataListener()");
            }

            @Override
            public void removeListDataListener(ListDataListener l) {
                System.out.println(".removeListDataListener()");
            }
    
}
