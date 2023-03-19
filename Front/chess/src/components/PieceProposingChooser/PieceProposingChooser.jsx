import { observer } from 'mobx-react';
import React, { useEffect } from 'react';
import { useContext } from 'react';
import { Context } from '../..';
import { BLACK, WHITE } from '../../utils/colors';
import { BISHOP, KNIGHT, QUEEN, ROOK } from '../../utils/pieceNames';
import PieceProposingButton from '../UI/Buttons/PieceProposingButton/PieceProposingButton';
import classes from './PieceProposingChooser.module.css'

const PieceProposingChooser = observer(({ cageWidth, boardPosition }) => {
    const { proposingChooserInfo, currentGame } = useContext(Context)
    const onSelect = proposingChooserInfo.onSelectPiece
    const onClose = () => {
        proposingChooserInfo.clear()
    }


    return (
        <div className={classes.wrapper} onClick={onClose}>
            <div className={classes.pieceProposingChooser} style={{
                top: currentGame.playerRole === BLACK ?
                    boardPosition.posY + cageWidth * (proposingChooserInfo.pawnPos.posY - 0.5) :
                    boardPosition.posY + cageWidth * (8.5 - proposingChooserInfo.pawnPos.posY) | 0,
                left: currentGame.playerRole === BLACK ?
                    boardPosition.posX + cageWidth * (8.5 - proposingChooserInfo.pawnPos.posX) :
                    boardPosition.posX + cageWidth * (proposingChooserInfo.pawnPos.posX - 0.5) | 0
            }}>
                <PieceProposingButton onCLick={() => onSelect(QUEEN)} playerRole={WHITE} pieceName={QUEEN}></PieceProposingButton>
                <PieceProposingButton onCLick={() => onSelect(KNIGHT)} playerRole={WHITE} pieceName={KNIGHT}></PieceProposingButton>
                <PieceProposingButton onCLick={() => onSelect(BISHOP)} playerRole={WHITE} pieceName={BISHOP}></PieceProposingButton>
                <PieceProposingButton onCLick={() => onSelect(ROOK)} playerRole={WHITE} pieceName={ROOK}></PieceProposingButton>
            </div>
        </div>
    );
});

export default PieceProposingChooser;