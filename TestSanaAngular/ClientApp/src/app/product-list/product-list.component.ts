import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService) { }
  public storageOptions: string[];
  ngOnInit() {
    /** spinner starts on init */
    this.spinner.show();
    this.getStorageOptions();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
  }

  getStorageOptions() {
    this.storageOptions = ['Persistent Storage', 'In-MemoryStorage', 'LocalStorage'];
  }

}
