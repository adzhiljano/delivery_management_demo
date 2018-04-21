import { Component, HostListener } from '@angular/core';
import { Shipment, ShipmentStatus } from './shipment';
import { ShipmentsService } from './shipmentsService';
import { Paging } from '../paging';
import { Observable } from 'rxjs/Rx';

@Component({
  selector: 'dm-shipmentsSearch',
  templateUrl: './shipmentsSearch.component.html'
})
export class ShipmentsSearchComponent {
  busy: any;
  shipments: Paging<Shipment>;
  shipment: Shipment = null;
  statusFilter?: ShipmentStatus = ShipmentStatus.OutForDelivery;
  shipmentStatuses = Object.keys(ShipmentStatus);
  pageOffset: number = 0;
  pageLimit: number = 5;
  pages: number[];
  currentPage: number = 1;
  mobileLayout: boolean = false;
  toggleAllIndicator: boolean = false;

  constructor(private shipmentsService: ShipmentsService) {
    this.onResize();
    this.getShipments();
  }

  viewShipment(shipment: any) {
    if (this.mobileLayout) {
      this.shipment = shipment;
    } else {
      shipment.toggle = !shipment.toggle;
    }
  }

  getShipments() {
    this.busy = this.shipmentsService.getShipments(this.statusFilter, this.pageOffset, this.pageLimit).subscribe(res => {
      this.shipments = res;
      this.pages = Array.from(Array(Math.ceil(res.count / this.pageLimit)), (v, k) => k + 1);
    });
  }

  shipmentUpdated(shipment: Shipment) {
    let s: Shipment = this.shipments.results.find(t => t.shipmentId == shipment.shipmentId);
    s.setAttributes(shipment);
  }

  filterShipments() {
    this.pageOffset = 0;
    this.currentPage = 1;
    this.getShipments();
  }

  setPage(page: number) {
    this.pageOffset = (page - 1) * this.pageLimit;
    this.currentPage = page;
    this.getShipments();
  }

  toggleAll(toggle: boolean) {
    if (this.shipments && this.shipments.results) {
      this.shipments.results.forEach(s => (<any>s).toggle = toggle);
    }
    this.toggleAllIndicator = toggle;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event?) {
    if (window.innerWidth < 450) {
      this.mobileLayout = true;
      this.toggleAll(false);
    } else {
      this.mobileLayout = false;
    }
  }
}
