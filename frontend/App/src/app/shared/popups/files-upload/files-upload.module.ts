import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilesUploadComponent } from './files-upload.component';



@NgModule({
  declarations: [
    FilesUploadComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    FilesUploadComponent
  ]
})
export class FilesUploadModule { }
