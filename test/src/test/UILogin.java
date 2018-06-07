/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.WindowConstants;

/**
 *
 * @author Administrator
 */
public class UILogin extends JFrame{
    public UILogin()
    {
        setBounds(0, 0, 400, 200);
        
        JLabel JLUser = new JLabel("ÓÃ»§Ãû");
        JTextField JTUser = new JTextField(10);
        JLabel JLPassword = new JLabel("ÃÜÂë");
        JPasswordField JPPassword = new JPasswordField(10);
       
        JPanel u = new JPanel();
        u.add(JLUser);
        u.add(JTUser);
        u.add(JLPassword);
        u.add(JPPassword);
        
        JLabel tip = new JLabel();
        JPanel c = new JPanel();
        c.add(tip);
        add(c,BorderLayout.CENTER);
        
        JButton jButton = new JButton("µÇÂ¼");
        jButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                List<Stu> AllStu = Dao.getAllStu();
                boolean flag=false;
                for (Stu stu : AllStu) {
                    if(Integer.parseInt(JTUser.getText())==stu.getId()&&stu.getName().equals(new String(JPPassword.getPassword())))
                    {
                        flag=true;
                        break;
                    }else{
                        flag=false;
                    }
                }
                if(flag)
                {
                    tip.setText("µÇÂ¼³É¹¦");
                    UIMain main = (UIMain)UIController.getMain();
                    main.tip.setText("µÇÂ¼³É¹¦");
                    main.if_log_in=true;
                    UIController.show(UIController.getMain());
                    UIController.hide(UILogin.this);
                            
                }
                else
                    tip.setText("µÇÂ¼Ê§°Ü");
            }
        });
        
        JPanel d = new JPanel();
        d.add(jButton);
        
        add(u,BorderLayout.NORTH);
        add(d,BorderLayout.SOUTH);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(WindowConstants.HIDE_ON_CLOSE);
        
        UIController.setLogIn(this);
        UIController.show(UIController.getLogIn());
                
    }
}
