import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { StorageType } from "../model/storage-type";
import  { StorageTypes } from "../helpers/enumerators";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService) { }
  public storageOptions: StorageType[];
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
    this.storageOptions = [
      new StorageType(StorageTypes.PersistantStorage, 'Persistent Storage'),
      new StorageType(StorageTypes.InMemory, 'In-MemoryStorage'),
      new StorageType(StorageTypes.LocalStorage, 'LocalStorage')
    ];
  }


}

