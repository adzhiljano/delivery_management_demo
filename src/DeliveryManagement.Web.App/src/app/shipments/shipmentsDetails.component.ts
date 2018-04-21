import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ShipmentsService } from './shipmentsService';
import { ShipmentStatus, Shipment } from './shipment';

@Component({
  selector: 'dm-shipmentsDetails',
  templateUrl: './shipmentsDetails.component.html'
})
export class ShipmentsDetailsComponent {
  @Input()
  shipment: Shipment;
  @Input()
  mobileLayout: boolean;
  @Output()
  onBack = new EventEmitter<boolean>();
  @Output()
  shipmentUpdated = new EventEmitter<Shipment>();
  mode?: ShipmentStatus;
  busy: any;
  shipmentStatuses = ShipmentStatus;

  constructor(private shipmentsService: ShipmentsService) {
  }

  undo() {
    this.busy = this.shipmentsService.resetShipment(this.shipment.shipmentId).subscribe(res => this.setShipment(res));
  }

  save() {
    if (this.mode === ShipmentStatus.Delivered) {
      this.busy = this.shipmentsService.changeStatusToDelivered(this.shipment.shipmentId, this.shipment).subscribe(res => this.setShipment(res));
    } else if (this.mode === ShipmentStatus.HeldInTruck) {
      this.busy = this.shipmentsService.changeStatusToHeldInTruck(this.shipment.shipmentId, this.shipment).subscribe(res => this.setShipment(res));
    }
    else {
      throw new Error('Mode is not correct');
    }
    this.mode = null;
  }

  setShipment(shipment: Shipment) {
    this.shipment = shipment;
    this.shipmentUpdated.emit(shipment);
  }
}
