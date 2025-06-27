using NUnit.Framework;
using System;

namespace TestColaPrioridad
{
    public class ColaPrioridadTests
    {
        private ColaPrioridad cola;

        [SetUp]
        public void Setup()
        {
            cola = new ColaPrioridad();
        }

        [Test]
        public void Enqueue_SingleItem_QueueIsNotEmpty()
        {
            cola.Encolar("A", 4);
            Assert.That(cola.IsEmpty(), Is.False, "Después de encolar un elemento, la cola no debería estar vacía.");
        }

        [Test]
        public void Dequeue_OneItem_ReturnsItemAndEmptiesQueue()
        {
            cola.Encolar("B", 2);
            var result = cola.Desencolar();

            Assert.That(result, Is.EqualTo("B"), "Tiene que devolver el único elemento encolado.");
            Assert.That(cola.IsEmpty(), Is.True, "Una vez desencolado ese elemento, la cola debería quedar vacía.");
        }

        [Test]
        public void Dequeue_MultipleItems_ReturnsItemWithHighestPriority()
        {
            cola.Encolar("A", 3);
            cola.Encolar("S", 1);
            cola.Encolar("D", 5);
            var result = cola.Desencolar();

            Assert.That(result, Is.EqualTo("S"), "Debe devolver el elemento con la prioridad más alta (número más bajo).");
        }

        [Test]
        public void Peek_MultipleItems_ReturnsHighestPriorityWithoutRemoving()
        {
            cola.Encolar("E", 2);
            cola.Encolar("F", 1);
            var result = cola.getMayorPrioridad();

            Assert.That(result, Is.EqualTo("F"), "Debe devolver el elemento con mayor prioridad sin eliminarlo.");
        }

        [Test]
        public void IsEmpty_NewQueue_ReturnsTrue()
        {
            Assert.That(cola.IsEmpty(), Is.True, "Una cola recién creada debe estar vacía.");
        }

        [Test]
        public void Dequeue_EmptyQueue_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => cola.Desencolar(), "Debería lanzar una excepción si se intenta desencolar cuando la cola está vacía.");
        }

        [Test]
        public void Peek_EmptyQueue_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => cola.getMayorPrioridad(), "Debería lanzar una excepción si se consulta el mayor elemento cuando la cola está vacía.");
        }

        [Test]
        public void Enqueue_SamePriorityItems_ReturnsFirstInserted()
        {
            cola.Encolar("X", 2);
            cola.Encolar("Y", 2);
            var result = cola.getMayorPrioridad();

            Assert.That(result, Is.EqualTo("X"), "Si dos elementos tienen la misma prioridad, debe devolver el que fue encolado primero.");
        }

        [Test]
        public void Enqueue_MultipleElements_QueueShouldNotBeEmpty()
        {
            for (int i = 1; i <= 50; i++)
            {
                cola.Encolar($"Dato-{i * 3}", (i % 4) + 1); 
            }

            Assert.That(cola.IsEmpty(), Is.False, "Luego de encolar múltiples elementos, la cola no debería estar vacía.");
        }
    }
}
