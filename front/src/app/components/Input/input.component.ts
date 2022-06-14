import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormControl } from "@angular/forms";

@Component({
  selector: "input-component",
  templateUrl: "./input.component.html",
  styleUrls: ["./input.component.scss"]
})
export class InputComponent implements OnInit {
  @Input("name") name: string = "";
  @Input("type") type: string = "text";
  @Input("className") className: string | string[] = "";
  @Input("control") control: any = new FormControl("");
  @Input("showLabel") showLabel: boolean = false;
  @Input("showBorder") showBorder: boolean = false;
  @Input("mask") mask: string = "";
  @Output("keyUp") keyUp: EventEmitter<any> = new EventEmitter();
  isFocused: boolean = false;

  ngOnInit(): void { }

  setFocus(value: boolean) {
    this.isFocused = value;
  }

  getClasses() {
    if (this.className) {
      if (Array.isArray(this.className)) return this.className.join(" ");
      return this.className;
    }
    return "";
  }

  getMask() {
    if (!this.mask) return undefined;
    switch (this.mask) {
      case "date":
        return "d0/M0/0000";
      default:
        return undefined;
    }
  }

  emitEnterKey(event: KeyboardEvent) {
    if (event && event.code === "Enter") this.keyUp.emit();
  }

  nameUpperCase(input: string) {
    return input.toUpperCase();
  }
}