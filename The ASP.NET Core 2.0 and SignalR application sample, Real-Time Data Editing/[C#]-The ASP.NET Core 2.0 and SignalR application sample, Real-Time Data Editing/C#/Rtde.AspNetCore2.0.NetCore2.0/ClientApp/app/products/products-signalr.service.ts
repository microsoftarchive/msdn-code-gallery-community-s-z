import { Inject, Injectable } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client'
import { Observable } from 'rxjs/Observable';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import { Product } from './product'

@Injectable()
export class ProductsSignalRService {
    private productMessageHub: HubConnection;

    private addObservable: ReplaySubject<Product>;
    private updateObservable: ReplaySubject<Product>;
    private removeObservable: ReplaySubject<number>;

    public productAddedEvent = () => this.addObservable.asObservable();
    public productUpdatedEvent = () => this.updateObservable.asObservable();
    public productDeletedEvent = () => this.removeObservable.asObservable();

    constructor( @Inject('BASE_URL') private baseUrl: string) {
        console.log(baseUrl);

        let url = baseUrl + 'ProductMessageHub';

        this.productMessageHub = new HubConnection(url);
        this.addObservable = new ReplaySubject<Product>();
        this.updateObservable = new ReplaySubject<Product>();
        this.removeObservable = new ReplaySubject<number>();
    }

    public startConnection(): void {
        if (typeof window !== 'undefined') {
            this.start();
        }
    }

    private start() {
        this.productMessageHub.start().then(
            () => {
                console.log('SignalR connected was established.');

                this.productMessageHub.on('ProductAdded',
                    data => {
                        let product = new Product();
                        product.id = data.Id;
                        product.name = data.Name;
                        product.description = data.Description;

                        this.productAdded(product);
                    });

                this.productMessageHub.on('ProductUpdated',
                    data => {
                        console.log(data);
                        let product = new Product();
                        product.id = data.Id;
                        product.name = data.Name;
                        product.description = data.Description;

                        console.log('productMessageHub.on(\'ProductUpdated\' ' + product.id + ' ' + data);

                        this.productUpdated(product);
                    });

                this.productMessageHub.on('ProductRemoved',
                    (data: any): void => {
                        let productId = data as number;
                        this.productRemoved(productId);
                    });
            }
        );
    }

    public addProduct(product: Product) {
        this.productMessageHub.invoke('addProduct', product);
    }

    public updateProduct(product: Product) {
        this.productMessageHub.invoke('updateProduct', product);
    }

    public removeProduct(productId: number) {
        this.productMessageHub.invoke('removeProduct', productId);
    }

    private productAdded(product: Product): void {
        this.addObservable.next(product);
    }

    private productUpdated(product: Product): void {
        console.log('productUpdated(product: Product) ' + product);
        this.updateObservable.next(product);
    }

    public productRemoved(productId: number): void {
        this.removeObservable.next(productId);
    }
}