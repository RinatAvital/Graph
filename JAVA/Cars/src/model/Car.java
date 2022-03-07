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

enum Company{
MAZDA(0), TOYOTA(50),SHEVROLET(100),NISAN(),AUDI(200),YONDI(),FORD(),HONDA(); 

    private Company(int add) {
        price+=add;
    }
}
enum Color{
WHITE, BLACK,PINK,GRAY,GRIN,BAG,BROUN,BLUE 
}
public class Car {
    private String kod;
    private Company company;
    private double kamash;
    private String model;
    private String shana;
    private Color color;
    private double price;
    

    public Car() {
    }

    public Car(String kod, Company company, double kamash, String model, String shana, Color color) {
        this.kod = kod;
        this.company = company;
        this.kamash = kamash;
        this.model = model;
        this.shana = shana;
        this.color = color;
    }

    

    public String getKod() {
        return kod;
    }

    public Company getCompany() {
        return company;
    }

    public double getKamash() {
        return kamash;
    }

    public String getModel() {
        return model;
    }

    public String getShana() {
        return shana;
    }

    public Color getColor() {
        return color;
    }

   

    public void setKod(String kod) {
        this.kod = kod;
    }

    public void setCompany(Company company) {
        this.company = company;
    }

    public void setKamash(double kamash) {
        this.kamash = kamash;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public void setShana(String shana) {
        this.shana = shana;
    }

    public void setColor(Color color) {
        this.color = color;
    }

    
    
    
    
    
    
    
}
