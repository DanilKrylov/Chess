import React from 'react';
import './PieceProposingButton.css'

const PieceProposingButton = ({playerRole, pieceName, onCLick}) => {
    return (
        <div onClick={onCLick} className={['pieceProposingButton', playerRole + '-' + pieceName].join(' ')}>
            
        </div>
    );
};

export default PieceProposingButton;