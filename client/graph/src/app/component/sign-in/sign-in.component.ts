import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { User } from 'src/app/models/User';
import { UserSignIn } from 'src/app/models/UserSignIn';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  signInForm: any;

  constructor(private db: DbService) { }

  ngOnInit(): void {

    this.signInForm = new FormGroup(
      {
        firstName: new FormControl(''),
        password: new FormControl('')
      }

    )
  }

  doSignIn() {
    console.log(this.signInForm)
    const user: UserSignIn = {
      firstName: this.signInForm.controls.fn.Value,
      password: this.signInForm.controls.ps.Value
    }
    console.log(user)
    
    this.db.newSignIn(user).subscribe(res=>{
      console.log(res);
      if(res==null)
        alert("שגיאת שרת");
      else
        alert("נוסף בהצלה")
    })
  }


}
