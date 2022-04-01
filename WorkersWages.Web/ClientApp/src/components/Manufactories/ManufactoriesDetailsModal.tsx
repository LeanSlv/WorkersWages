import { AisModal, AisGrid } from "@ais-gorod/react-ui";
import { useEffect, useState } from "react";
import { useHistory, useParams } from 'react-router-dom';
import { WorkersWagesApiClient, ManufactoryDetailsResponse } from '../../services/WorkersWagesApiClient';

export const ManufactoriesDetailsModal = () => {
    const history = useHistory();
    const { id } = useParams() as {
        id: string;
    };

    const [manufacoryInfo, setManufacoryInfo] = useState<ManufactoryDetailsResponse>();
    useEffect(() => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        apiClient.manufactoriesDetails(+id).then((r) => setManufacoryInfo(r));
    }, []);

    if (!manufacoryInfo) return null;

    return (
        <AisModal show={true} onHide={() => history.goBack()} title="Подробности цеха">
            <AisGrid.Row>
                <AisGrid.Col className="text-center">
                    <div>** Сюда добавить фотографию **</div>
                    <strong>{manufacoryInfo.headFIO}</strong>
                </AisGrid.Col>
                <AisGrid.Col>
                    <div>
                        <strong>Название: </strong> {manufacoryInfo.name}
                    </div>
                    <div>
                        <strong>Номер: </strong> {manufacoryInfo.number}
                    </div>
                </AisGrid.Col>
            </AisGrid.Row>
        </AisModal>
    );
};

ManufactoriesDetailsModal.displayName = 'ManufactoriesDetailsModal';
