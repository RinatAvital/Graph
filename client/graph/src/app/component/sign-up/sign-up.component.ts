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
    debugger;
    const user: User = {
      code:10,
      firstName: this.signUpForm.controls.firstName.value,
      lastName: this.signUpForm.controls.lastName.value,
      userName: this.signUpForm.controls.userName.value,
      email: this.signUpForm.controls.email.value,
      password: this.signUpForm.controls.password.value
    }
    console.log(user)
    debugger
  
    this.db.newSignUp(user).subscribe(
      res => {
        debugger;
        console.log(res);
        this.db.user2 = res;
        alert("נוסף בהצלחה");
      },
      err => console.log("error: " + err.message)
    )
  }

}
