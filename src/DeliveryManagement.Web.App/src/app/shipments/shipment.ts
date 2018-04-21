export enum ShipmentStatus {
    OutForDelivery = <any>"OutForDelivery",
    Delivered = <any>"Delivered",
    HeldInTruck = <any>"HeldInTruck"
}

export class Shipment {

    constructor(data: any) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    shipmentId: number;
    trackingNumber: string;
    senderName: string;
    senderAddress: string;
    receiverName: string;
    receiverAddress: string;
    packagesCount: number;
    status: ShipmentStatus;
    hasDamagedPackages?: boolean;
    receiverFound?: boolean;
    notes: string;
    truckId?: number
    createDate: string;
    modifyDate: string;
    version: string;

    public setAttributes(shipment: Shipment) {
        this.status = shipment.status;
        this.hasDamagedPackages = shipment.hasDamagedPackages;
        this.receiverFound = shipment.receiverFound;
        this.notes = shipment.notes;
        this.modifyDate = shipment.modifyDate;
        this.version = shipment.version;
    }
}