/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package bangmonhoc;

import java.util.Vector;

/**
 *
 * @author lebao
 */
public class bangMH {
    public String mamh;
    public String tenmh;
    public int sotc;
    public bangMH() {
    }
    public bangMH(String mamh, String tenmh, int sotc) {
        this.mamh = mamh;
        this.tenmh = tenmh;
        this.sotc = sotc;
    }
    public void in(){
        System.out.println(mamh+","+tenmh+","+sotc);
        
    }
    /**
     * @return the mamh
     */
    public String getMamh() {
        return mamh;
    }

    /**
     * @param mamh the mamh to set
     */
    public void setMamh(String mamh) {
        this.mamh = mamh;
    }

    /**
     * @return the tenmh
     */
    public String getTenmh() {
        return tenmh;
    }

    /**
     * @param tenmh the tenmh to set
     */
    public void setTenmh(String tenmh) {
        this.tenmh = tenmh;
    }

    /**
     * @return the sotc
     */
    public int getSotc() {
        return sotc;
    }

    /**
     * @param sotc the sotc to set
     */
    public void setSotc(int sotc) {
        this.sotc = sotc;
    }
    
}
