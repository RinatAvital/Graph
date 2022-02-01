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
public class Customer {
    private long id;
    private String name;
    private String addrsess;

    public Customer() {
    }

    public Customer(long id, String name, String addrsess) {
        this.id = id;
        this.name = name;
        this.addrsess = addrsess;
    }

    public long getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getAddrsess() {
        return addrsess;
    }

    public void setId(long id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setAddrsess(String addrsess) {
        this.addrsess = addrsess;
    }
    
    
}
