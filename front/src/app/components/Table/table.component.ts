import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from "@angular/core";
import { Subject, takeUntil } from "rxjs";

export interface ITableComponents {
  headers: string[];
  values: any[];
  ignore?: string[]
}

@Component({
  selector: "table",
  templateUrl: "./table.component.html",
  styleUrls: ["./table.component.scss"]
})
export class TableComponent {
  @Input("componentes") components: ITableComponents = {
    headers: [],
    values: []
  };
  @Output() clicked: EventEmitter<any> = new EventEmitter();

  constructor() { }
  getComponentProperties(object: any) {
    const properties = Object.keys(object);
    if (this.components.ignore) {
      return properties.filter(property => !this.components.ignore?.includes(property));
    }
    return properties;
  }

  rowClicked(component: any) {
    this.clicked.emit(component);
  }
}