import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { User } from 'src/app/models/User';
import { UserSignIn } from 'src/app/models/UserSignIn';
import { Router } from '@angular/router';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  signInForm: any;

  constructor(private db: DbService, public router:Router) { }

  ngOnInit(): void {

    this.signInForm = new FormGroup(
      {
        userName: new FormControl(''),
        password: new FormControl('')
      }

    )
  }

  doSignIn() {
    console.log(this.signInForm)
    debugger;
    const user: UserSignIn = {
      userName: this.signInForm.controls.userName.value,
      password: this.signInForm.controls.password.value
    }
    console.log(user)

    this.db.newSignIn(user).subscribe(
      res => {
        debugger;
        this.db.user2 = res;
        alert("משתמש קיים עודכן בהצלחה");
        
        this.router.navigate(['/draw']);
      },
      err => console.log("error: " + err.message)
    )
  }


}
