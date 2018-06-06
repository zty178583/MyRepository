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
public class UIGetScore extends JFrame{
    public Model model;
    public static JTextField score_textField;
    public UIGetScore()
    {
        //添加combox
        JPanel n = new JPanel();
        JComboBox<Stu> jComboBox = new JComboBox(new Model());
        n.add(jComboBox);
        add(n,BorderLayout.NORTH);
        
        //显示UI
        score_textField = new JTextField(10);
        score_textField.setEditable(false);
        JPanel c = new JPanel();
        c.add(score_textField);
        add(c);
        //panel包装并加入窗口
        JPanel d = new JPanel();
        add(d,BorderLayout.SOUTH);
        //设置窗口属性
        setBounds(0, 0, 600, 200);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setVisible(true);
    }
}
