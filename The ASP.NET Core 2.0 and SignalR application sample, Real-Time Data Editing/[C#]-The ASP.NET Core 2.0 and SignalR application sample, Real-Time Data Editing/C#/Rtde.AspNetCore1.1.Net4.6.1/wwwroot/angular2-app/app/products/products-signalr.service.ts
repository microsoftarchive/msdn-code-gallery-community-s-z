import { Inject, Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ReplaySubject } from 'rxjs/ReplaySubject';
import { Product } from './product'

declare var $: any;

@Injectable()
export class ProductsSignalRService {

    private connection: any;
    private productMessageHub: any;
    private addObservable: ReplaySubject<Product>;
    private updateObservable: ReplaySubject<Product>;
    private removeObservable: ReplaySubject<number>;

    public productAddedEvent = () => this.addObservable.asObservable();
    public productUpdatedEvent = () => this.updateObservable.asObservable();
    public productDeletedEvent = () => this.removeObservable.asObservable();

    constructor( @Inject('BASE_URL') private baseUrl: string) {
        this.connection = $.hubConnection(baseUrl + 'signalr/');
        this.productMessageHub = this.connection.createHubProxy('productMessageHub');

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
        this.registerOnServerEvents();
        this.connection.start().done((data: any) => {
            console.log('Now connected ' + data.transport.name + ', connection ID= ' + data.id);
        }).fail((error: any) => {
            console.log('Could not connect ' + error);
        });
    }

    private registerOnServerEvents(): void {

        this.productMessageHub.on('productAdded',
            (data: any) => {
                let product = new Product();
                product.id = data.Id;
                product.name = data.Name;
                product.description = data.Description;

                this.productAdded(product);
            });

        this.productMessageHub.on('productUpdated',
            (data: any) => {
                console.log(data);
                let product = new Product();
                product.id = data.Id;
                product.name = data.Name;
                product.description = data.Description;

                console.log('productMessageHub.on(\'ProductUpdated\' ' + product.id + ' ' + data);

                this.productUpdated(product);
            });

        this.productMessageHub.on('productRemoved',
            (data: any): void => {
                let productId = data as number;
                this.productRemoved(productId);
            });
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