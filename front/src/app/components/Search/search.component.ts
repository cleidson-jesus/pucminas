import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormControl } from "@angular/forms";

@Component({
  selector: "search-component",
  templateUrl: "./search.component.html",
  styleUrls: ["./search.component.scss"]
})
export class SearchComponent implements OnInit {
  @Input("name") name: string = "";
  @Input("control") control: FormControl = new FormControl("");
  @Input("className") className: string | string[] = "";
  @Output("keyUp") keyUp: EventEmitter<any> = new EventEmitter();
  isFocused: boolean = false;

  ngOnInit(): void {

  }

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

  emitEnterKey(event: KeyboardEvent) {
    if (event && event.code === "Enter") this.keyUp.emit();
  }
}