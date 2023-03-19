import React, { useContext, useState } from 'react';
import './Piece.css'
import { observer } from 'mobx-react';
import { Context } from '../..';
import { BLACK } from '../../utils/colors';

const Piece = observer(({pieceIdentifier, tryMove, setTargetFigure}) => {
    const {currentGame} = useContext(Context)
    const piece = currentGame.getPiece(pieceIdentifier);
    const [isHandled, setIsHandled] = useState(false);

    function handleClick(event) {
        if (event.button !== 0) {
            return;
        }
        
        if (isHandled) {
            currentGame.setViewPosAsValidPos(pieceIdentifier);
            setIsHandled(false)
            setTargetFigure(false)
            return
        }

        setIsHandled(true)
        setTargetFigure({pieceIdentifier: pieceIdentifier, unhandleClick: () => setIsHandled(false)})
    }

    async function unhandleClick() {
        if (!isHandled) {
            return
        }

        setTargetFigure(false)
        setIsHandled(false)

        const newPos = {
            posX: Math.round(piece.position.posX),
            posY: Math.round(piece.position.posY)
        }

        if (!await tryMove(piece.validPosition, newPos)) {
            currentGame.setViewPosAsValidPos(pieceIdentifier)
        }
    }

    return (
        <div
            key={Math.random()}
            className={['chess-piece', piece.color + '-' + piece.name, isHandled && 'handled'].join(' ')}
            onMouseDown={handleClick}
            onMouseUp={unhandleClick}
            style={{
                transform: currentGame.playerRole === BLACK ? 
                    `translate(${(8 - piece.position.posX) * 100}%, ${(piece.position.posY - 1) * 100}%)` :
                    `translate(${(piece.position.posX - 1) * 100}%, ${(8 - piece.position.posY) * 100}%)`                 
            }}
        ></div>
    );
});

export default Piece;