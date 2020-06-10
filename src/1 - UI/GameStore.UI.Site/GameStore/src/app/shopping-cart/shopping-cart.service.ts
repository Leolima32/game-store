import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ShoppingCartService {
    
    constructor(private httpClient: HttpClient) {

    }

    addToCart(id: string): Observable<any> {
        throw new Error("Method not implemented.");
    }
    
}