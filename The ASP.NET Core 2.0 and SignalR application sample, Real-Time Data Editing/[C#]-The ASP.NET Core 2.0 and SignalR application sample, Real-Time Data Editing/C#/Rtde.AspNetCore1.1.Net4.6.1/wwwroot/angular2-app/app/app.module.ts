import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { ProductsService } from './products/products.service';
import { ProductsSignalRService } from './products/products-signalr.service';

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule, JsonpModule],

    declarations: [AppComponent, ProductsComponent],

    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        ProductsService,
        ProductsSignalRService
    ],

    bootstrap: [AppComponent]
})

export class AppModule { }

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}