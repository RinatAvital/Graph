/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package model;

/**
 *
 * @author רינת אביטל
 */

enum Darga{
    A, B, C, D, E
}

public class CommercialVehicle extends Car{
    
    private Darga darga;
    private int moshav;
    private double price;

    public CommercialVehicle() {
    }

    public CommercialVehicle(Darga darga, int moshav, double price, String kod, Company company, double kamash, String model, String shana, Color color) {
        super(kod, company, kamash, model, shana, color);
        this.darga = darga;
        this.moshav = moshav;
        this.price = price;
    }

    

    
    
    

    
    
    
    
    
}
