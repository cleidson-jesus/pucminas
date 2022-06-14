import { Component, Input } from "@angular/core";

@Component({
  selector: "button-component",
  templateUrl: "./button.component.html",
  styleUrls: ["./button.component.scss"]
})
export class ButtonComponent {
  @Input("name") name: string = "";
  @Input("height") height: string = "" || "40px";
  @Input("className") className: string | string[] = "";

  getClasses() {
    if (this.className) {
      if (Array.isArray(this.className)) return this.className.join(" ");
      return this.className;
    }
    return "";
  }
}