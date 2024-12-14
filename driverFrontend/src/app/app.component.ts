import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Driver } from './models/driver';
import { AsyncPipe } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HttpClientModule, AsyncPipe, FormsModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'driverFrontend';
  http = inject(HttpClient);

  driverForm = new FormGroup({

    name: new FormControl<string>(''),
    number: new FormControl<number>(0),
    team: new FormControl<string>('')

  })

  drivers$ = this.getDriver();

  onFormSubmit(){

    const addDriverRequest = {
      name: this.driverForm.value.name,
      number: this.driverForm.value.number,
      team: this.driverForm.value.team
    }

    this.http.post('https://localhost:44386/Api/Drivers',addDriverRequest)
    .subscribe({
      next: (value) => {
        console.log(value);
        this.drivers$ = this.getDriver();
        this.driverForm.reset();
      }
    })

  }

  private getDriver(): Observable<Driver[]>{

    return this.http.get<Driver[]>('https://localhost:44386/Api/Drivers');

  }


}
