/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import java.awt.BorderLayout;
import java.awt.Menu;
import java.awt.MenuBar;
import java.awt.MenuItem;
import java.awt.Panel;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.WindowConstants;

/**
 *
 * @author Administrator
 */
public class UIMain extends JFrame{
    public boolean if_log_in=false;
    public JTextField tip;
    public UIMain(){
        //�˵���
        MenuBar menuBar = new MenuBar();
        
        Menu menu = new Menu("����");
        MenuItem insert = new MenuItem("����");
        insert.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if(if_log_in)
                {
                    JFrame i = UIController.getInsert();
                    UIController.show(i);
                }else{
                    JOptionPane.showMessageDialog(null, "���ȵ�¼", "��ʾ", JOptionPane.OK_OPTION);
                }
            }
        });
        MenuItem get_score = new MenuItem("��ѯ");
        get_score.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if(if_log_in)
                {
                    JFrame getScore = new UIGetScore();
                    UIController.show(getScore);
                }else{
                    JOptionPane.showMessageDialog(null, "���ȵ�¼", "��ʾ", JOptionPane.OK_OPTION);
                }
            }
        });
        
        MenuItem delete = new MenuItem("ɾ��");
        delete.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                if(if_log_in)
                {
                    JFrame uidelete = new UIDelete();
                    UIController.show(uidelete);
                }else{
                    JOptionPane.showMessageDialog(null, "���ȵ�¼", "��ʾ", JOptionPane.OK_OPTION);
                }
            }
        });
        menu.add(insert);
        menu.add(get_score);
        menu.add(delete);
        menuBar.add(menu);
        
        //����
        tip = new JTextField(10);
        tip.addMouseListener(new MouseListener() {
            @Override
            public void mouseClicked(MouseEvent e) {
                if(!if_log_in)
                {
                    JFrame logIn = UIController.getLogIn();
                    UIController.show(logIn);
                }
            }

            @Override
            public void mousePressed(MouseEvent e) {

            }

            @Override
            public void mouseReleased(MouseEvent e) {
                
            }

            @Override
            public void mouseEntered(MouseEvent e) {
                if(!if_log_in)
                    tip.setText("�����¼");
            }

            @Override
            public void mouseExited(MouseEvent e) {
               if(!if_log_in) 
                   tip.setText("��δ��¼");
            }
        });
        tip.setText("��δ��¼");
        tip.setEditable(false);
        Panel c = new Panel();c.add(tip);
        add(c,BorderLayout.CENTER);
        //���ô�������??????
        //��Ӳ˵���
        setMenuBar(menuBar);
        setBounds(0, 0, 600, 200);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        
        UIController.setMain(this);
        UIController.show(UIController.getMain());
    }
    
}
