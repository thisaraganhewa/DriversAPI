import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Driver } from './models/driver';
import { AsyncPipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HttpClientModule, AsyncPipe, FormsModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'driverFrontend';
  http = inject(HttpClient);

  drivers$ = this.getDriver();

  private getDriver(): Observable<Driver[]>{

    return this.http.get<Driver[]>('https://localhost:44386/Api/Drivers');

  }


}
