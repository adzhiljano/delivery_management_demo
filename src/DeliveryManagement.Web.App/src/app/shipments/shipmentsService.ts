import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Shipment, ShipmentStatus } from './shipment';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Paging } from '../paging';
import 'rxjs/add/operator/map'

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable()
export class ShipmentsService {
    url: string = "api/shipments";
    constructor(private http: HttpClient) { }

    getShipments(status?: ShipmentStatus, offset?: number, limit?: number): Observable<Paging<Shipment>> {
        let params = new HttpParams();
        params = status !== null ? params.append('status', status.toString()) : params;
        params = offset !== null ? params.append('offset', offset.toString()) : params;
        params = limit !== null ? params.append('limit', limit.toString()) : params;
        return this.http.get<Paging<Shipment>>(this.url, { params: params }).map(res => {
            let paging = new Paging<Shipment>();
            paging.count = res.count;
            paging.results = [];
            res.results.forEach(r => paging.results.push(new Shipment(r)));
            return paging;
        });
    }

    changeStatusToDelivered(shipmentId: number, shipment: Shipment): Observable<Shipment> {
        return this.http.post<Shipment>(`${this.url}/${shipmentId}/changeStatusToDelivered`, shipment, httpOptions);
    }

    changeStatusToHeldInTruck(shipmentId: number, shipment: Shipment): Observable<Shipment> {
        return this.http.post<Shipment>(`${this.url}/${shipmentId}/changeStatusToHeldInTruck`, shipment, httpOptions);
    }

    resetShipment(shipmentId: number): Observable<Shipment> {
        return this.http.post<Shipment>(`${this.url}/${shipmentId}/resetShipment`, {}, httpOptions);
    }
}