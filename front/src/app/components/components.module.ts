import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { IConfig, NgxMaskModule } from "ngx-mask";
import { ButtonComponent } from "./Button/button.component";
import { InputComponent } from "./Input/input.component";
import { LoadingComponent } from "./Loading/loading.component";
import { SearchComponent } from "./Search/search.component";
import { SelectComponent } from "./Select/select.component";
import { SidebarComponent } from "./Sidebar/sidebar.component";
import { TableComponent } from "./Table/table.component";
import { WrapperLabelCommponent } from "./WrapperLabel/wrapperLabel.component";

const components = [
  SidebarComponent,
  TableComponent,
  LoadingComponent,
  InputComponent,
  ButtonComponent,
  SelectComponent,
  SearchComponent,
  WrapperLabelCommponent
]

const maskConfig: Partial<IConfig> = {
  validation: true,
  dropSpecialCharacters: false
}

@NgModule({
  declarations: components,
  imports: [
    CommonModule,
    NgxMaskModule.forRoot(maskConfig),
    ReactiveFormsModule
  ],
  exports: components
})
export class ComponentsModule { }