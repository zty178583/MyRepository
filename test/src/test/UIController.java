/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import javax.swing.JFrame;

/**
 *
 * @author Administrator
 */
public class UIController {
    private static JFrame GetScore;
    private static JFrame Insert;
    private static JFrame LogIn;
    private static JFrame Main;
    
    public static void show(JFrame op)
    {
        if(op!=null)
            op.setVisible(true);
        else
            System.out.println("ø’÷∏’Î");
    }
    public static void hide(JFrame op)
    {   if(op!=null)
            op.setVisible(false);
        else
            System.out.println("ø’÷∏’Î");
    }

    /**
     * @return the GetScore
     */
    public static JFrame getGetScore() {
        if(GetScore==null)
            setGetScore(new UIGetScore());
        return GetScore;
    }
    /**
     * @return the Insert
     */
    public static JFrame getInsert() {
        if(Insert==null)
            setInsert(new UIInsert());
        return Insert;
    }
    /**
     * @return the LogIn
     */
    public static JFrame getLogIn() {
        if(LogIn==null)
            setLogIn(new UILogin());
        return LogIn;
    }
    /**
     * @return the Main
     */
    public static JFrame getMain() {
        if(Main==null)
            setMain(new UIMain());
        return Main;
    }

    /**
     * @param aGetScore the GetScore to set
     */
    public static void setGetScore(JFrame aGetScore) {
        GetScore = aGetScore;
    }

    /**
     * @param aInsert the Insert to set
     */
    public static void setInsert(JFrame aInsert) {
        Insert = aInsert;
    }

    /**
     * @param aLogIn the LogIn to set
     */
    public static void setLogIn(JFrame aLogIn) {
        LogIn = aLogIn;
    }

    /**
     * @param aMain the Main to set
     */
    public static void setMain(JFrame aMain) {
        Main = aMain;
    }
}
