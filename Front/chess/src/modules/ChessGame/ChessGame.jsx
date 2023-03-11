import React, { useEffect, useState } from 'react';
import ChessBoard from '../../components/ChessBoard/ChessBoard';
import { PieceInfo } from '../../components/Piece/PieceInfo';
import { joinToGameHub, leftGameHub, movePiece, setOnMoveByApponent} from '../../http/gameAPI';

const ChessGame = () => {
    const [pieces, setPieces] = useState([])
    useEffect(() => {
        joinToGameHub(onMoveByApponent, gameInfoSetter, localStorage.getItem('game'))
        return leftGameHub()
    }, [])

    useEffect(() => {
        setOnMoveByApponent(onMoveByApponent)
    })

    function gameInfoSetter(game){
        console.log(game)
        setPieces(game.pieces)
    }

    function onMoveByApponent(p){
        console.log([...p]);
        setPieces(prevPieces =>
            prevPieces.map(piece => {
              const updatedPiece = p.find(newPiece => newPiece.pieceIdentifier === piece.pieceIdentifier && 
                                        (newPiece.posX !== piece.posX || newPiece.posY !== piece.posY));
              return updatedPiece || piece;
            })
          );
    }

    async function movePieceByPlayer(from, to){
        await movePiece(localStorage.getItem('game'), from, to)
    }


    return (
        <ChessBoard pieces={pieces} cageWidth={50} fromColor='White' canMove={() => true} onMove = {movePieceByPlayer}></ChessBoard>
    );
};

export default ChessGame;