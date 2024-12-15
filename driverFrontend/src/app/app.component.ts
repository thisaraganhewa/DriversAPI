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


  //submit new driver form data
  driverForm = new FormGroup({

    name: new FormControl<string>(''),
    number: new FormControl<number>(0),
    team: new FormControl<string>('')

  })

  //update driver form data
  driverUpdateForm = new FormGroup({

    name: new FormControl<string>(''),
    number: new FormControl<number>(0),
    team: new FormControl<string>('')

  })

  //id to send to update
  updateID: string = "";
  drivers$ = this.getDriver();//display drivers

  onFormSubmit(){

    //assigning the data to send through the url
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

  //setting the input fields to display the value
  onUpdateSet( id: string, name: string, number: number, team: string){


    this.driverUpdateForm.patchValue({
      name: name,
      number: number,
      team: team,
    })


    this.updateID = id;

  }

  // onUpdateSet( item: any ){

  //   this.driverUpdateForm = {...item};

  //   this.updateID = item.id;

  // }

  //update a driver
  onUpdate(){

    const updateDriverRequest = {

      name: this.driverUpdateForm.value.name,
      number: this.driverUpdateForm.value.number,
      team: this.driverUpdateForm.value.team

    }

    this.http.put(`https://localhost:44386/Api/Drivers/${this.updateID}`, updateDriverRequest)
    .subscribe({
      next: (value) =>{

        alert(`Driver ${updateDriverRequest.number} is updated`)
        this.drivers$ = this.getDriver();

      }
    })

  }

  //delete a driver
  onDelete(id: string){

    console.log(id)

    this.http.delete(`https://localhost:44386/Api/Drivers/${id}`)
    .subscribe({
      next: (value) => {
        console.log(value);
        alert('item deleted');
        this.drivers$ = this.getDriver();
      }
    })

  }

  //display drivers
  private getDriver(): Observable<Driver[]>{

    return this.http.get<Driver[]>('https://localhost:44386/Api/Drivers');

  }


}
