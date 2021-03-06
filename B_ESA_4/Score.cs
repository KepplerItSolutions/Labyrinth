﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using B_ESA_4.EventStream;
using B_ESA_4.Playground;

namespace B_ESA_4
{
    class Score : IDisposable
    {
        private readonly CompositeDisposable _subscriptions;

        public int Steps { get; private set; }

        public int Points { get; private set; } = 0;

        public Score()
        {
            _subscriptions = new CompositeDisposable
            {
                MyEventStream.Instance.Of<PawnMovedEvent>().Subscribe(HandlePawnMoved),
                MyEventStream.Instance.Of<ItemCollectedEvent>().Subscribe(HandleItemCollected),
                MyEventStream.Instance.Of<AllItemsCollectedEvent>().Subscribe(HandleAllItemsCollected)
            };
        }

        private void HandlePawnMoved(PawnMovedEvent movedEvent)
        {
            Steps++;
        }
        private void HandleItemCollected(ItemCollectedEvent collectedEvent)
        {
            Points += 10;
        }
        private void HandleAllItemsCollected(AllItemsCollectedEvent collectedEvent)
        {
            Points += CalculateBonus();
        }
        private int CalculateBonus()
        {
            return (int)(Points * (4 / (float)Steps));
        }

        #region IDisposable Support
        private bool _disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _subscriptions.Dispose();
                }
                _disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(true);
        }
        #endregion

    }
}
