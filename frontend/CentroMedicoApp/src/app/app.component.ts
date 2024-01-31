import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PacienteService } from './Services/paciente.service';
import { paciente } from './Interfaces/Paciente';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  _listaPacientes:paciente[] = [];
  _pacienteSeleccionado!:paciente;
  formPaciente:FormGroup;

  constructor(
    private _pacienteService:PacienteService,
    private _formBuilder:FormBuilder
  ){
    this.formPaciente = this._formBuilder.group({
      nombres: ["", Validators.required],
      apellidos: ["", Validators.required],
      tipoDocumento: ["", Validators.required],
      numeroDocumento: ["", Validators.required],
      ciudadResidencia: ["", Validators.required]
    });
  }

  ngOnInit(): void {
    this.ListarPacientes();
  }

  ListarPacientes(){
    this._pacienteService
      .ListarPacientes()
      .subscribe({
        next:(data) => {
          this._listaPacientes = data;
        },
        error:(e) => {console.log("Error: ", e);}
      });
  }

  ObtenerPaciente(id:number){
    this._pacienteService
      .ObtenerPaciente(id)
      .subscribe({
        next:(data) => {
          this._pacienteSeleccionado = data;
        },
        error:(e) => {console.log("Error: ", e);}
      });
  }

  CrearPaciente(){
    const pacienteNuevo:paciente = {
      pacienteId: 0,
      nombres: this.formPaciente.value.nombres,
      apellidos: this.formPaciente.value.apellidos,
      tipoDocumento: this.formPaciente.value.tipoDocumento,
      numeroDocumento: this.formPaciente.value.numeroDocumento,
      ciudadResidencia: this.formPaciente.value.ciudadResidencia,
      fechaNaciemiento: ""
    }

    this._pacienteService
      .CrearPaciente(pacienteNuevo)
      .subscribe({
        next:(data) => {
          this._listaPacientes.push(data);
          this.formPaciente.patchValue({
            nombres: "",
            apellidos: "",
            tipoDocumento: "",
            numeroDocumento: "",
            ciudadResidencia: "",
            fechaNaciemiento: ""
          })
        },
        error:(e) => {console.log("Error: ", e);}
      });
  }
}
