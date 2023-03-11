import React, { useState } from 'react';
import './Piece.css'

const Piece = (props) => {
    const { pieceInfo, setTargetFigure, canMove, fromColor, onMove } = props;
    const [viewPos, setViewPos] = useState(pieceInfo.position)
    const [isHandled, setIsHandled] = useState(false);
    const [validPos, setValidPos] = useState(pieceInfo.position);

    function handleClick(event) {
        if (event.button !== 0) {
            return;
        }
        
        if (isHandled) {
            setViewPos({ ...validPos })
            setIsHandled(false)
            setTargetFigure(undefined)
            return
        }

        setIsHandled(true)
        setTargetFigure({setViewPos})
    }

    async function unhandleClick(event) {
        if (!isHandled) {
            return
        }

        setTargetFigure(false)
        setIsHandled(false)

        const newPos = {
            posX: Math.round(viewPos.posX),
            posY: Math.round(viewPos.posY)
        }

        if (canMove(validPos, newPos)) {
            await onMove(validPos, newPos)
            setViewPos(newPos)
            setValidPos(newPos)
        }
        else {
            setViewPos({ ...validPos })
        }
    }

    return (
        <div
            key={Math.random()}
            className={`chess-piece ${pieceInfo.color}-${pieceInfo.name}`}
            onMouseDown={handleClick}
            onMouseUp={unhandleClick}
            style={{
                transform: fromColor === 'black' ? 
                    `translate(${(8 - viewPos.posX) * 100}%, ${(viewPos.posY - 1) * 100}%)` :
                    `translate(${(viewPos.posX - 1) * 100}%, ${(8 - viewPos.posY) * 100}%)`                 
            }}
        ></div>
    );
};

export default Piece;