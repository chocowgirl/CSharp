﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo11InterfaceFiltre.Models
{
    internal class Bateau : IPlaceable, IAttackable
    {
        private int _positionX;
        private int _positionY;
        private int _length;


        public int PositionX   //Property
        {
            get 
            {
                return _positionX;
            }
            set
            {
                if (value <= 0) _positionX = 1;
                else if (value > 10) _positionX = 10;
                else _positionX = value;
            } 
        }

        public int PositionY //Property
        {
            get { return _positionY; }
            set
            {
                if (value <= 0) _positionY = 1;
                else if (value > 10) _positionY = 10;
                else _positionY = value;
            }
        }

        public int Length  //Property
        {
            get { return _length; }
            set
            {
                if (value <= 1) _length = 2;
                else if (value > 5) _length = 5;
                else _length = value;
            }
        }

        public bool IsHorizontal { get; set; }  //Property

        public Bateau(int length)
        {
            Length = length;
        }

        public void SetPosition(int posX, int posY, bool isHorizontal) 
        {
            PositionX = posX;
            PositionY = posY;
            IsHorizontal = isHorizontal;
        }

        public bool FireOn(int posX, int posY)
        {
            if (IsHorizontal)
            {
                if (PositionY == posY)
                {
                    if (posX >= PositionX && posX <= PositionX + Length)
                    {
                        return true;
                    }
                }
                return false;
                //this whole block could be written as:
                //return PositionY == posY && posX >= PositionX && posX <= (PositionX + Length);
            }
            else
            {
                return PositionX == posX && posY <= PositionY && posY <= (PositionY + Length);
            }
        }
    }
}
