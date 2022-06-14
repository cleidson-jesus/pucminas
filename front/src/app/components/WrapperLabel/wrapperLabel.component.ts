import { Component, Input } from "@angular/core";

@Component({
  selector: "wrapper",
  templateUrl: "./wrapperLabel.component.html",
  styleUrls: ["./wrapperLabel.component.scss"],
})
export class WrapperLabelCommponent {
  @Input("name") name: string = "";
}