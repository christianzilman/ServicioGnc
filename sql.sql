
Tipo Concepto

insert into TipoConcepto(Nombre)values('Haber')
insert into TipoConcepto(Nombre)values('Debe')

Concepto
Utilidad 1 importe
Utilidad 2 porcentaje

Tipo Concepto Haber 1
Tipo Concepto Debe 2

insert into Concepto(Nombre,Porcentaje,Importe,Utilidad,TipoConceptoId) values('Sueldo Basico',0,1000,1,1)
insert into Concepto(Nombre,Porcentaje,Importe,Utilidad,TipoConceptoId) values('Obra Social',10,0,2,2)
insert into Empresa(Nombre,Cuit)values('Gasnor','991345667')
insert into Rol(Nombre)values('Empleado');
insert into Rol(Nombre)values('Cliente');


insert into Horario(ComienzoTurno,FinalTurno)values('08:00','17:00')

insert into Horario(ComienzoTurno,FinalTurno)values('08:00 - 12:00 | ','13:00 - 18:00')



insert into TipoEstado(Nombre) values('Pagada');
insert into TipoEstado(Nombre) values('Anulada');