using System;
using System.Collections.Generic;

// Implementacion de cola de prioridad utilizando Lista de Tuplas
// La tupla se compone de:
    // Item: Valor de tipo String
    // Priority: Indicador de prioridad, donde el 1 es la prioridad mas alta
public class ColaPrioridad{
    private List<(string Item, int Priority)> _cola;

    public ColaPrioridad(){
        _cola = new List<(string, int)>();
    }

    // Agregar un elemento con prioridad
    public void Encolar(string item, int priority){
        _cola.Add((item, priority));
    }

    // Extraer el elemento de mayor prioridad (menor valor de prioridad)
    public string Desencolar(){
        // Encontrar el índice del elemento con menor prioridad
        int highPriorityIndex = 0;
        for (int i = 1; i < _cola.Count; i++){
            if (_cola[i].Priority < _cola[highPriorityIndex].Priority){
                highPriorityIndex = i;
            }
        }

        // Extraer el elemento con mayor prioridad
        var highPriorityItem = _cola[highPriorityIndex].Item;
        _cola.RemoveAt(highPriorityIndex);

        return highPriorityItem;
    }

    // Obtener el elemento de mayor prioridad sin eliminarlo
    public string getMayorPrioridad(){
        int highPriorityIndex = 0;
        for (int i = 1; i < _cola.Count; i++){
            if (_cola[i].Priority < _cola[highPriorityIndex].Priority){
                highPriorityIndex = i;
            }
        }

        return _cola[highPriorityIndex].Item;
    }

    // Verificar si la cola está vacía
    public bool IsEmpty(){
        return _cola.Count == 0;
    }
}
