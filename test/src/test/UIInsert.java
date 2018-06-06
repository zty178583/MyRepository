/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.WindowConstants;

/**
 *
 * @author Administrator
 */
public class UIInsert extends JFrame{
    public UIInsert()
    {       
        //插入UI
        JLabel JLId = new JLabel("id：");
        JTextField JTId = new JTextField(10);
        JLabel JLName = new JLabel("姓名：");
        JTextField JTName = new JTextField(10);
        JLabel score_label= new JLabel("分数");
        JTextField score_iTextField = new JTextField(10);
        //插入按钮
        JButton jButton = new JButton("插入");
        jButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                //新建对象并赋值
                Stu stu = new Stu();
                stu.setId(Integer.parseInt(JTId.getText()));
                stu.setName(JTName.getText());
                stu.setScore(Integer.parseInt(score_iTextField.getText()));
                //保存
                Dao.save(stu);
            }
        });
        //panel包装并加入窗口
        JPanel d = new JPanel();
        d.add(JLId);
        d.add(JTId);
        d.add(JLName);
        d.add(JTName);
        d.add(score_label);
        d.add(score_iTextField);
        d.add(jButton);
        add(d,BorderLayout.CENTER);
        //设置窗口属性
        setBounds(0, 0, 600, 200);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setVisible(true);
    }
}
