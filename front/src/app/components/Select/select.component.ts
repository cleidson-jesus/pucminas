import { Component, Input } from "@angular/core";
import { FormControl } from "@angular/forms";

export interface IInputSelectOptions {
  name: string;
  value: string | number | boolean;
}

@Component({
  selector: "select-component",
  templateUrl: "./select.component.html",
  styleUrls: ["./select.component.scss"]
})
export class SelectComponent {
  @Input("name") name: string = "";
  @Input("options") options: IInputSelectOptions[] = [];
  @Input("control") control: FormControl = new FormControl(undefined);
}
