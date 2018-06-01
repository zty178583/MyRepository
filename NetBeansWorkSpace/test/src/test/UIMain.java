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
public class UIMain extends JFrame{
    public Model model;
    public UIMain()
    {
        JComboBox<Stu> jComboBox = new JComboBox(new Model());
        JPanel c = new JPanel();
        c.add(jComboBox);
        add(c,BorderLayout.CENTER);
        
        //insert
        JLabel JLId = new JLabel("id：");
        JTextField JTId = new JTextField(10);
        
        JLabel JLName = new JLabel("姓名：");
        JTextField JTName = new JTextField(10);
        
        JButton jButton = new JButton("插入");
        jButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                Stu stu = new Stu();
                stu.setId(Integer.parseInt(JTId.getText()));
                stu.setName(JTName.getText());
                Dao.save(stu);
                jComboBox.setModel(new Model());
            }
        });
        
        JPanel d = new JPanel();
        d.add(JLId);
        d.add(JTId);
        d.add(JLName);
        d.add(JTName);
        d.add(jButton);
        add(d,BorderLayout.SOUTH);
        
        setBounds(0, 0, 400, 200);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setVisible(true);
    }
}
