import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-dcxresult',
  templateUrl: './dcxresult.component.html',
  styleUrls: ['./dcxresult.component.scss'],
})
export class DCXResultComponent {
  @Input() journies: any;  

}
