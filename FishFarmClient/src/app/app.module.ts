import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent, Safe } from './app.component';
import { FishFarmService } from './services/fishfarm.service';

@NgModule({
  declarations: [
    AppComponent,
    Safe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [FishFarmService],
  bootstrap: [AppComponent]
})
export class AppModule { }
