import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup,FormBuilder } from '@angular/forms';
import { DbService } from 'src/app/service/db.service';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  signUpForm: any;


  constructor(private db: DbService) { }

  ngOnInit(): void {

    this.signUpForm = new FormGroup(
      {
        firstName: new FormControl(''),
        lastName: new FormControl(''),
        userName: new FormControl(''),
        email: new FormControl(''),
        password: new FormControl('')
      }

    )
  }

  doSignUp() {
    console.log(this.signUpForm)
    const user: User = {
      code:5,
      firstName: this.signUpForm.controls.fn.Value,
      lastName: this.signUpForm.controls.ln.Value,
      userName: this.signUpForm.controls.un.Value,
      email: this.signUpForm.controls.em.Value,
      password: this.signUpForm.controls.ps.Value
    }
    console.log(user)
    
    this.db.newSignUp(user).subscribe(res=>{
      console.log(res);
      if(res==null)
        alert("שגיאת שרת");
      else
        alert("נוסף בהצלה")
    })
  }

}
