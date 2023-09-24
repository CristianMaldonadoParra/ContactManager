import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: 'agruparPorLetra'
})
export class AgruparPorLetraPipe implements PipeTransform {
  transform(items: any[]): any[] {
    const grupos: any = {};
    items.forEach(item => {
      const letraInicial = item.grupo.toUpperCase();
      if (!grupos[letraInicial]) {
        grupos[letraInicial] = [];
      }
      grupos[letraInicial].push(item);
    });

    const gruposOrdenados = Object.keys(grupos).sort();
    return gruposOrdenados.map(letra => ({ letra, pessoas: grupos[letra] }));
  }
}
