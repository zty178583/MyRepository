/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.WindowConstants;

/**
 *
 * @author Administrator
 */
public class UIDelete extends JFrame{

    public UIDelete(){
        List<Stu> allStu = Dao.getAllStu();
        JPanel main = new JPanel();
        JTextField id;
        JTextField name;
        JButton btn_delete;
        JButton btn_update;
            for (Stu stu : allStu) {
                id = new JTextField(3);
                id.setText(stu.getId()+"");
                name = new JTextField(10);
                name.setText(stu.getName());
                btn_delete = new JButton("删除");
                btn_update= new JButton("修改");
                btn_delete.addActionListener(new ActionListener() {
                    @Override
                    public void actionPerformed(ActionEvent e) {
                        Dao.delete(stu);
                        dispose();
                        new UIDelete();
                    }
                });
                btn_update.addActionListener(new ActionListener() {
                    @Override
                    public void actionPerformed(ActionEvent e) {
                        String text = id.getText();
                        stu.setName("");
                    }
                });
                main.add(id);
                main.add(name);
                main.add(btn_delete);
            }
        add(main);
        //设置窗口属性
        setBounds(0, 0, 600, 200);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(WindowConstants.HIDE_ON_CLOSE);
        setVisible(true);
    }
}
