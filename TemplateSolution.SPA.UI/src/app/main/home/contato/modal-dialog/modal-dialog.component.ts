import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ContatoModel } from '../../../../model/ContatoModel';
import { ContatoService } from '../../../../common/ContatoService';

@Component({
  selector: 'app-modal-dialog',
  templateUrl: './modal-dialog.component.html',
  styleUrls: ['./modal-dialog.component.scss']
})
export class ModalDialogComponent implements OnInit {
  constructor(public dialogRef: MatDialogRef<ModalDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ContatoModel, private contatoService: ContatoService) {

  }
  ngOnInit(): void {
    console.log(this.data);
  }

  onSalvarContato() {
    if (this.data.id == 0) {
      this.contatoService.create(this.data).subscribe((result) => {
        this.dialogRef.close();
      });
    }
    else {
      this.contatoService.update(this.data).subscribe((result) => {
        this.dialogRef.close();
      });
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
