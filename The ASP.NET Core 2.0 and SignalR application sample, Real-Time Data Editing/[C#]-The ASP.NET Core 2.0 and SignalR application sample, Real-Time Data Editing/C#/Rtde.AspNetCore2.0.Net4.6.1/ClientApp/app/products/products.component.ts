import { Component, OnInit } from '@angular/core'
import { ProductsService } from './products.service'
import { ProductsSignalRService } from './products-signalr.service'
import { Product } from './product'

@Component({
    selector: 'products',
    templateUrl: './products.component.html'
})

export class ProductsComponent implements OnInit {
    private canSendMessage: Boolean;

    private allMessages: string[];
    private products: Product[];

    private selectedProduct?: Product;
    private lastAddedProduct?: Product;

    public componentStatus: string = 'App started!';
    public addNewProductAllowed = true;

    constructor(private productsService: ProductsService,
        private productsSignalRService: ProductsSignalRService) {
        this.allMessages = new Array<string>();
        this.selectedProduct = new Product();

        this.productsSignalRService.productAddedEvent().subscribe(product => this.productAdded(product));
        this.productsSignalRService.productUpdatedEvent().subscribe(product => this.productUpdated(product));
        this.productsSignalRService.productDeletedEvent().subscribe(productId => this.productDeleted(productId));
    }

    public ngOnInit() {
        this.getProducts();
        this.productsSignalRService.startConnection();
        this.allMessages.push(`Application started at: ${new Date().toLocaleTimeString()}.`);
    }

    public addNewProduct() {
        this.addNewProductAllowed = false;

        this.lastAddedProduct = new Product();
        this.lastAddedProduct.name = 'New product';

        this.selectedProduct = this.lastAddedProduct;
    }

    public deleteProduct(): void {
        if (this.selectedProduct != null) {
            this.productsSignalRService.removeProduct(this.selectedProduct.id);
        } else {
            this.componentStatus = 'Please select a product from the table.';
        }
    }

    public updateProduct() {
        if (this.lastAddedProduct != null && this.addNewProductAllowed === false) {
            this.productsSignalRService.addProduct(this.lastAddedProduct);
            this.addNewProductAllowed = true;
        } else {
            this.productsSignalRService.updateProduct(this.selectedProduct as Product);
        }
    }

    private getProducts() {
        this.products = this.productsService.products;

        this.productsService.getProducts()
            .subscribe((response: Product[]) => {
                    this.products = response;
                },
                (err: any) => console.log(err),
                () => console.log('getProducts() retrieved customers'));
    }

    public setClickedRow(product: Product): void {
        this.selectedProduct = product;
        this.addNewProductAllowed = true;
        this.lastAddedProduct = undefined;
        console.log(`Selected product is ${product}`);
    }

    private productAdded(product: Product) {
        this.allMessages.push(`Product with Id: ${product.id} added.`);
        this.products.push(product);
    }

    private productUpdated(product: Product) {
        let productsForUpdate = this.products.filter(p => p.id === product.id);
        if (productsForUpdate && productsForUpdate[0]) {
            productsForUpdate[0].name = product.name;
            productsForUpdate[0].description = product.description;
            this.allMessages.push(`Product with Id: ${product.id} updated.`);
        }
    }

    private productDeleted(productId: number) {
        this.allMessages.push(`Product with Id: ${productId} deleted.`);
        this.products = this.products.filter(product => product.id !== productId);
    }
}