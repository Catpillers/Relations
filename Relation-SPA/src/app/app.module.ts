import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RelationTableComponent } from './relation-table/relation-table.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';




@NgModule({
   declarations: [
      AppComponent,
      RelationTableComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BsDropdownModule.forRoot(),
      BrowserAnimationsModule,

   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
